const child_process = require('child_process');
const EventEmitter = require('events');

class ChildProcess extends EventEmitter {
  constructor(command, args, env, options = {}) {
    super();

    this.command = command;
    this.args = args;
    this.env = env;
    this.isStarted = false;
    this.verbose = options.verbose;
    this.outputData = '';
    this.serviceId = options.serviceId || command;
    this.sentinel = options.sentinel || [];
    if (!Array.isArray(this.sentinel)) {
      this.sentinel = [this.sentinel];
    }
  }

  get pid() {
    if (!this.childProcess) {
      return null;
    }

    return this.childProcess.pid;
  }

  writeToStdout(data) {
    if (this.verbose) {
      process.stdout.write(`[${this.serviceId}]: ` + data);
    }

    if (this.isStarted) {
      return;
    }

    this.outputData += data.toString().trim();

    this.isStarted = this.sentinel.every(item => {
      if (item instanceof RegExp) {
        return item.test(this.outputData);
      }

      return data.indexOf(item) >= 0;
    });

    if (this.isStarted) {
      this.outputData = null;

      this.emit('started');
    } else if (this.sentinel.length === 0) {
      this.emit('data', data);
    }
  }

  start() {
    this.childProcess = child_process.spawn(this.command, this.args, {
      cwd: process.cwd(),
      encoding: 'utf8',
      env: this.env,
      stdio: ['pipe', 'pipe', 'pipe', 'ipc']
    });

    this.childProcess.on('error', error => {
      console.error(error.stack);

      this.emit('error', error);
    });

    this.childProcess.stdout.on('data', data => this.writeToStdout(data));
    this.childProcess.stderr.on('data', data => this.writeToStdout(data));

    return this;
  }

  stop(done = function() {}) {
    this.childProcess.on('exit', code => {
      console.log(`[${this.serviceId}]: Child process ${this.command} exited with code ${code}.`);
      done();
    });

    this.childProcess.kill();

    if (require('os').platform() === 'win32') {
      const spawn = require('child_process').spawn;
      spawn('taskkill', ['/pid', this.childProcess.pid, '/f', '/t']);

      return;
    }

    this.childProcess.kill();

    return this;
  }

  static create(command, args, env, opts) {
    return new Promise(function (resolve, reject) {
      let childProcess = new ChildProcess(command, args, env, opts);

      childProcess.on('started', function () {
        resolve(childProcess);
      });

      childProcess.on('error', function (err) {
        reject(err);
      });

      childProcess.start();
    })
  }
}

module.exports = ChildProcess;
