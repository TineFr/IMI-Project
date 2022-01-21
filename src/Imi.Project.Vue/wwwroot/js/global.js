

var global = new Vue({
    el: "header",
    data: {
        navBarIsVisible: sessionStorage.getItem("navbar"),
    },
    methods: {

        logOut : function () {
            sessionStorage.removeItem('token');
            sessionStorage.removeItem("navbar");
            window.location = '/auth/login';
        }
    },

    watch: {

    }

});