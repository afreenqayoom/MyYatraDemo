/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {},
    },
    variants: {
        extend: {
            display: ['group-focus'],
            opacity: ['group-focus'],
            inset: ['group-focus']
        },
    },
    plugins: [],
}

