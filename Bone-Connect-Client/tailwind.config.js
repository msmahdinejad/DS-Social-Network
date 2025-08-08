/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        custom: {
          light: "#FFE6C9",
          dark: "#631E4D",
          medium: "#7F265B",
        },
      },
    },
  },
  plugins: [],
};
