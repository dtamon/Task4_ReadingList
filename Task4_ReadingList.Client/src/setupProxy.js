﻿const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/book",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7179',
        secure: false
    });

    app.use(appProxy);
};
