const path = require('path');
const webpack = require('webpack');

module.exports = {
    mode: 'development',
    resolve: {
        extensions: [".js", ".ts", '.scss']
    },
    entry: {
        presentationSass: './Client/sass/main.scss',
        presentationJs:'./Client/ts/main.ts'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: '[name].bundle.js'
    },
    devServer: {
        contentBase: ".",
        host: "localhost",
        port: 9000
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            {
                test: /\.scss$/,
                use: [
                    { loader: 'style-loader' },
                    { loader: 'css-loader' },
                    { loader: 'sass-loader' }
                ]
            },
            {
                test: /.(ttf|otf|eot|svg|woff(2)?)(\?[a-z0-9]+)?$/,
                use: [{
                    loader: 'file-loader',
                    options: {
                        name: '[name].[ext]',
                        outputPath: 'fonts/',    // where the fonts will go
                        publicPath: '../'       // override the default path
                    }
                }]
            }
        ]
    }
};