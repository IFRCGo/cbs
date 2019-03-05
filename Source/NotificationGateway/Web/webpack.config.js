const path = require('path');
const dotenv = require('dotenv-webpack');
require('dotenv').config();

process.env.DOLITTLE_WEBPACK_ROOT = path.resolve('./');
process.env.DOLITTLE_WEBPACK_OUT = path.resolve('./dist');
process.env.DOLITTLE_FEATURES_DIR = path.resolve('./Features');
process.env.DOLITTLE_COMPONENT_DIR = path.resolve('./Components');

const config = require('@dolittle/build.react/webpack.config.js');

const modified = (env, argv) => {
    const base = config(arguments);
    base.plugins.push(
        new dotenv({
            path: './Environments/'+argv.mode+'.env'
        })
    );
    base.devServer = {
        port: 4010
    };
    return base;
}

module.exports = modified;
