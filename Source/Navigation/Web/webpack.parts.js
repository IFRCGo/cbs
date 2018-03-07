const CleanWebpackPlugin = require("clean-webpack-plugin");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");



let sassBuilder = new ExtractTextPlugin({
    filename: "style.bundle.css",
    allChunks: true
});

module.exports = {
    loaders: {
        htmlLoader: {
            test: /\.html$/,
            exclude: /index.html/,
            use: [
                {
                    loader: 'html-loader',
                    options: {
                        attrs: ["img:src", "link:href"],
                        interpolate: true,
                    }
                }],
        },
        sassLoader: {
            test: /\.scss$/,
            loader: sassBuilder.extract([
                "css-loader",
                "sass-loader",
                {
                    loader: "postcss-loader",
                    options: {
                        plugins: () => ([
                            require("autoprefixer")()
                        ])
                    }
                }])
        },
        svgLoader: {
            test: /\.svg/,
            exclude: /\/fonts\/bootstrap/,
            use: {
                loader: 'svg-inline-loader',
                options: {
                    removeTags: true,
                    removingTags: ['title', 'desc'],
                    removingTagAttrs: ['id', 'data-name']
                    
                }
            }
        },
        fontLoader: {
            test: /\.(ttf|eot|woff|woff2|svg)$/,
            exclude: /\/assets\/images/,
            loader: "file-loader",
            options: {
                name: "fonts/[name].[ext]",
            },
        },
    },
    plugins: {
        cleanDistFolderAndIndexfile: new CleanWebpackPlugin(["dist/*"]),
        buildHtmlIndex: new HtmlWebpackPlugin({
            template: "./src/index.html",
            filename: 'index.html'
        }),
        sassBuilder: sassBuilder
    }
}