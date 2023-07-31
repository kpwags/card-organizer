const colors = require('tailwindcss/colors');

module.exports = {
    content: [
        './**/*.html',
        './**/*.razor',
        './**/*.cshtml',
    ],
    darkMode: 'media',
    theme: {
        colors: {
            primary: 'rgb(0, 104, 34)',
            transparent: 'transparent',
            paleGray: 'rgb(243 244 246)',
            lightGray: 'rgb(63 63 70)',
            darkGray: 'rgb(24, 24, 27)',
            black: colors.black,
            white: colors.white,
            gray: colors.gray,
            red: colors.red,
            yellow: colors.amber,
            green: colors.emerald,
            blue: colors.blue,
            indigo: colors.indigo,
            purple: colors.violet,
            pink: colors.pink,
        },
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [],
}