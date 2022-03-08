const path = require("path");
const cracoAlias = require("craco-alias");
module.exports = {
    eslint: {
        enable: false
    },
    plugins: [
        {
            plugin: cracoAlias,
            options: {
                baseUrl: "./src",
                source: "tsconfig",
                tsConfigPath: "./tsconfig.base.json",
            },
        },
    ],
    webpack: {
        alias: {
            "@": path.resolve(__dirname, "./src"),
        },
    },
    style: {
        postcss: {
            plugins: [require("tailwindcss"), require("autoprefixer")],
        },
    },
};
