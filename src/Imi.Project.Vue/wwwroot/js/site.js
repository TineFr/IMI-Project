﻿
var login = new Vue({
    el: '#divLogIn',
    data: {
        loginRequest: {
            email: "",
            password: ""
        },
        errors: {
            password: [],
            email : []
        },
        IsValid: true,
        apiErrorMessage: null,
    },
    methods: {

        validateRequest: function () {
            this.IsValid = true;
            this.errors.password = [];
            this.errors.email = [];
            if (!this.loginRequest.email) {
                this.IsValid = false;
                this.errors.email.push("Email is required.");
            } else this.validateEmail(this.loginRequest.email);
            if (!this.loginRequest.password) {
                this.IsValid = false;
                this.errors.password.push("Password is required.");
            } 
        },
        validateEmail: function (email) {
            var regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!regex.test(email)) {
                this.errors.email.push("Not a valid e-mail adress");
                this.IsValid = false;
            }
        },
        login: function () {
            this.apiErrorMessage = null;
            this.validateRequest();
            if (this.IsValid) {
                var url = "https://localhost:5001/api/auth/login";
                axios.post(url, this.loginRequest)
                    .then(function (response) {

                        if (reponse.data.errors == null) {
                            localStorage.setItem("token", response.data.jwt)
                        }
                    })
                    .catch((error) => {
                        const response = error?.response;
                        this.apiErrorMessage = response.data;
                    })
            }
        }
    }
});




