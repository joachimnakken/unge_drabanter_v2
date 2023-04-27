/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        // primary
        primary: "#6750A4",
        "primary-container": "#EADDFF",
        "on-primary": "#FFFFFF",
        "on-primary-container": "#21005E",
        "inverse-primary": "#D0BCFF",
        // secondary
        secondary: "#625B71",
        "secondary-container": "#E8DEF8",
        "on-secondary": "#FFFFFF",
        "on-secondary-container": "#1E192B",
        // tertiary
        tertiary: "#7D5260",
        "tertiary-container": "#FFD8E4",
        "on-tertiary": "#FFFFFF",
        "on-tertiary-container": "#370B1E",
        // Surface
        surface: "#FEF7FF",
        "surface-dim": "#DED8E1",
        "surface-bright": "#FEF7FF",
        "surface-container-lowest": "#FFFFFF",
        "surface-container-low": "#F7F2FA",
        "surface-container": "#F3EDF7",
        "surface-container-high": "#ECE6F0",
        "surface-container-highest": "#E6E0E9",
        "surface-variant": "#E7E0EC",
        "on-surface": "#1C1B1F",
        "on-surface-variant": "#49454E",
        "inverse-surface": "#313033",
        "inverse-on-surface": "#F4EFF4",

        // Background
        background: "#FEF7FF",
        "on-background": "#1C1B1F",
        error: "#B3261E",
        "error-container": "#F9DEDC",
        "on-error": "#FFFFFF",
        "on-error-container": "#410E0B",

        // outline
        outline: "#79747E",
        "outline-variant": "#C4C7C5",

        // shadow
        shadow: "#000000",
        "surface-tint": "#6750A4",
        scrim: "#000000",
      },
    },
  },
  plugins: [],
};
