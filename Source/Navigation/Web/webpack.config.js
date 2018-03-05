const path = require('path');
const configParts = require("./webpack.parts");

module.exports = [{
    entry: ['./src/scripts/index.js', './src/styles/scss/style.scss'],
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist')
    },
    module: {
        rules: [
            configParts.loaders.htmlLoader,
            configParts.loaders.sassLoader
        ]
    },
    plugins: [
        configParts.plugins.cleanDistFolderAndIndexfile,
        configParts.plugins.sassBuilder,
        configParts.plugins.buildHtmlIndex
    ],
    devServer: {
        contentBase: './dist',
        port: 9999,
        open: true
    }
}];
