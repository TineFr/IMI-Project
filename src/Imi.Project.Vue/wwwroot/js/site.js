// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var isInVisible  = true;

const globalStore = new Vue({
    data: {
        isInVisible: true,
    }
})


var login = new Vue({
    el: '#divLogIn',
    data: {
        isInVisible,
    },
    methods: {
        ToggleNavBarVisibility: function () {
            var self = this;
            self.isInVisible = true;
        },
    created: function () {
        this.appName = "test worked";
    }
    }});

var layout = new Vue({
    el: 'header',
    data: {
        isInVisible
    }
})


var selectionBoxes = new Vue({
    el: ".paginationDiv",
    data: {
        ShowSelectionBoxes: false,
    },
    methods: {
        ToggleShowSelectionBoxes: function () {
            this.ShowSelectionBoxes = !this.ShowSelectionBoxes;
        },
    }
});
