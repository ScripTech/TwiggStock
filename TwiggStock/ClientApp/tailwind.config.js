/* eslint-disable @typescript-eslint/no-var-requires */
const { fontFamily } = require('tailwindcss/defaultTheme');

module.exports = {
    purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
    darkMode: false, // or 'media' or 'class'
    theme: {
         extend: {
            fontFamily: {
                primary: ['Pilat', ...fontFamily.sans],
                content: ['Pilat light', ...fontFamily.sans],
                bold: ['Pilat heavy', ...fontFamily.sans],
            },
            colors: {
                "dp-primary-linear": "transparent linear-gradient( 90deg,#1e1343 0%,#312a82 53%,#5154b6 100%) 0% 0% no-repeat padding-box",
                "dp-primary": "rgb(30, 20, 80)",
                "dp-green": "rgb(0, 230, 140)",
                'indigo-lighter': '#b3bcf5',
                'indigo': '#5c6ac4',
                'indigo-dark': '#202e78',
            },
        },
    },
    variants: {
        extend: {
            backgroundColor: ["responsive", "hover", "focus", "checked"],
            fontFamily: ["hover", "focus"],

        },
    },
    plugins: [],
};
