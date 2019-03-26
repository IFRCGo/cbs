const HeadlessBrowserMode = JSON.parse(process.env.HEADLESS_MODE || false);

const Webdriver = {
  ChromeDriver: {
    server_path: './node_modules/.bin/chromedriver',
    port: 9515
  },
  SafariDriver: {
    server_path: '/usr/bin/safaridriver',
    port: 4444
  }
};

const Capabilities = {
  Chrome: {
    browserName: 'chrome',
    chromeOptions: {
      args: HeadlessBrowserMode ? ['--headless'] : [],
    },
  },

  Firefox: {
    browserName: 'firefox',
    'moz:firefoxOptions': {
      args: HeadlessBrowserMode ? ['-headless'] : [],
    },
  },

  Safari: {
    browserName: 'safari',
  }
};

module.exports = {
  src_folders: ['./test/src'],
  globals_path: './test/lib/globals.js',

  webdriver: {
    start_process: true,
    ...Webdriver.ChromeDriver
  },

  test_settings: {
    'default': {
      // The default URL where the Parcel bundler dev servers runs
      // make sure to run "npm start" beforehand
      launch_url : 'http://localhost:1234',

      globals: {
        waitForConditionTimeout: 10000
      },

      desiredCapabilities: Capabilities.Chrome,
    },

    jsDisabled: {
      desiredCapabilities: {
        browserName: 'firefox',
        'moz:firefoxOptions': {
          args: ['-headless'],
          prefs: {
            'javascript.enabled': false,
          },
        },
      },
    },

    firefox: {
      desiredCapabilities: Capabilities.Firefox
    },

    // IMPORTANT:
    // make sure to run "/usr/bin/safaridriver --enable" to enable Webdriver control in Safari
    safari: {
      desiredCapabilities: Capabilities.Safari
    }
  },

};
