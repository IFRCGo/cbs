const path = require('path');
const fs = require('fs');
const webpack = require('webpack');

const dotenv = require('dotenv-webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');

const { ProvidePlugin, WatchIgnorePlugin } = require('webpack');
const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');

const ensureArray = (config) => config && (Array.isArray(config) ? config : [config]) || [];
const when = (condition, config, negativeConfig) => condition ? ensureArray(config) : ensureArray(negativeConfig);

const title = process.env.TITLE || '';
const rootDir = process.env.WEBPACK_ROOT || process.cwd();
const outDir = process.env.WEBPACK_OUT || path.resolve('./dist');
const baseUrl = process.env.WEBPACK_BASE_URL || '/analytics/';

const nodeModulesDir = path.resolve(__dirname, 'node_modules');

if (!fs.existsSync(outDir)) fs.mkdirSync(outDir);

module.exports = (env, argv) => {
    const production = argv.mode == 'production';

    return {
        resolve: {
            extensions: ['.js'],
            modules: [path.resolve('src'), 'node_modules'],
            mainFields: ['main', 'module']
        },

        entry: path.resolve('src/index.js'),

        mode: production ? 'production' : 'development',
        devtool: production ? 'nosources-source-map' : 'cheap-module-eval-source-map',

        devServer: {
            historyApiFallback: true,
            port: 4010,
            openPage: 'analytics/',
            proxy: {
                '/api': 'http://localhost:5010'
            },
            hot: true
        },
        output: {
            path: outDir,
            publicPath: baseUrl,
            filename: '[name].[hash].bundle.js',
            sourceMapFilename: '[name].[hash].bundle.map',
            chunkFilename: '[name].[hash].chunk.js'
        },
        performance: { hints: false },

        module: {
            rules: [
                {
                    test: /\.css$/,
                    use: ['style-loader', 'css-loader'],
                    issuer: /\.[tj]s$/i
                },
                {
                    test: /\.css$/,
                    use: ['css-loader'],
                    issuer: /\.html?$/i
                },            
                {
                    test: /\.scss$/,
                    use: ['style-loader', 'css-loader', 'sass-loader'],
                    issuer: /\.[tj]s$/i
                },
                {
                    test: /\.scss$/,
                    use: ['css-loader', 'sass-loader'],
                    issuer: /\.html?$/i
                },
                { test: /\.html$/i, loader: 'html-loader' },
                {
                    test: /\.js$/i, 
                    exclude: /(node_modules|bower_components)/,
                    loader: 'babel-loader'
                },
                // use Bluebird as the global Promise implementation:
                { test: /[\/\\]node_modules[\/\\]bluebird[\/\\].+\.js$/, loader: 'expose-loader?Promise' },
                // embed small images and fonts as Data Urls and larger ones as files:
                { test: /\.(png|gif|jpg|cur)$/i, loader: 'url-loader', options: { limit: 8192 } },
                { test: /\.woff2(\?v=[0-9]\.[0-9]\.[0-9])?$/i, loader: 'url-loader', options: { limit: 10000, mimetype: 'application/font-woff2' } },
                { test: /\.woff(\?v=[0-9]\.[0-9]\.[0-9])?$/i, loader: 'url-loader', options: { limit: 10000, mimetype: 'application/font-woff' } },
                // load these fonts normally, as files:
                { test: /\.(ttf|eot|svg|otf)(\?v=[0-9]\.[0-9]\.[0-9])?$/i, loader: 'file-loader' }
            ]
        },

        plugins: [
            new webpack.HotModuleReplacementPlugin(),
            new CleanWebpackPlugin([`${outDir}/**/*.*`], {  root: rootDir }),
            new WatchIgnorePlugin([
                '**/for_*/*.js',
                '**/when_*/*.js',
                '**/specs/*.js'
            ]),
            new ProvidePlugin({
                'Promise': 'bluebird'
            }),
            new dotenv({
                path: './Environments/'+argv.mode+'.env'
            }),
            new HtmlWebpackPlugin({
                template: fs.existsSync('index.ejs')? 
                    path.join('index.ejs')
                    : path.join(featureDir, 'index.html'),
                minify: production ? {
                    removeComments: true,
                    collapseWhitespace: true
                } : undefined,
                metadata: {
                    // available in index.ejs //
                    title, baseUrl
                }
            }),
        ]
    }
};