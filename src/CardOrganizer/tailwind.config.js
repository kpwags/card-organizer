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
            brandBlue: '#2b59c0',
            transparent: 'transparent',
            current: 'currentColor',
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