const { ChildProcess } = require('@ifrc-cbs/nodejs-server');
let serverProcess;
let parcelProcess;

module.exports = {
    before(done) {
        console.log('Starting the Frontend dev server');
        const parcelPromise = ChildProcess.create(
            'npx',
            ['parcel', './public/index.html'],
            Object.assign(
                {
                    NODE_ENV: 'nightwatch',
                    PORT: 9001,
                },
                process.env
            ),
            {
                sentinel: /Built in ([0-9.]+)s\.$/,
                verbose: true,
                serviceId: 'frontend-dev-server',
            }
        );

        console.log('Starting CBS dev server on port 9001...');
        const cbsNodePromise = ChildProcess.create(
            'npx',
            ['cbs-node-server'],
            Object.assign(
                {
                    NODE_ENV: 'nightwatch',
                    PORT: 9001,
                },
                process.env
            ),
            {
                sentinel: 'CBS Server listening',
                verbose: true,
                serviceId: 'cbs-node-server',
            }
        );

        Promise.all([parcelPromise, cbsNodePromise]).then(
            ([parcelChildProcess, nodeChildProcess]) => {
                serverProcess = nodeChildProcess;
                parcelProcess = parcelChildProcess;

                done();
            }
        );
    },

    after(done) {
        if (serverProcess) {
            serverProcess.stop();
            parcelProcess.stop(done);
        } else {
            done();
        }
    },
};
