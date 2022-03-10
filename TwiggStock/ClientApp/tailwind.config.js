/* eslint-disable @typescript-eslint/no-var-requires */
const { fontFamily } = require("tailwindcss/defaultTheme");

module.exports = {
  purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      fontFamily: {
        primary: ["Pilat", ...fontFamily.sans],
        content: ["Pilat light", ...fontFamily.sans],
        bold: ["Pilat heavy", ...fontFamily.sans],
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
