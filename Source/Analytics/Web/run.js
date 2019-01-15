#!/usr/local/bin/node
const glob = require('glob');
const path = require('path');
const karma = require('karma');
const webpack = require('webpack');
const { spawn } = require('child_process');

// { production: true }

const webpackConfig = require('./webpack.config.js')();

const compiler = webpack(webpackConfig);

compiler.watch({
    // Example watchOptions
    aggregateTimeout: 300,
    poll: undefined
}, (err, stats) => {
    if( err || stats.hasErrors() ) {
        console.log(err || stats.compilation.errors);
    } else {
        console.log("(web)Packed and all is good")
    }
});

/*
let karmaOptions = {
    configFile : path.resolve('./karma.conf.js')
};
let server = new karma.Server(karmaOptions).start()
*/

glob("../Core/*.csproj", (err, matches) => {
    if (matches.length) {
        let dotnet = spawn('dotnet', ['watch','run'], {cwd: '../Core'});
        dotnet.stdout.on('data', (data) => {
            console.log(data.toString());
        });

        dotnet.stderr.on('data', (data) => {
            console.log(data.toString());
        });
    } else {
        console.log('<--- No .csproj file - not running "dotnet" --->')
    }
});
