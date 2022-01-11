// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let app = new Vue({
    el: '#app',
    data: {
        message: `Vue in the works!`
    }
})

let layout = new Vue({
    el: 'header',
    data: {
        isInVisible: true,
    }
})

