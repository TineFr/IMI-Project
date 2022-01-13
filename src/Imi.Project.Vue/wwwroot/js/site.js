
var axiosConfig = { headers: { "Content-Type": "application/json" } };

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
            } /*else this.validatePassword(this.loginRequest.password);*/
        },
        validateEmail: function (email) {
            var regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!regex.test(email)) {
                this.errors.email.push("Not a valid e-mail adress");
                this.IsValid = false;
            }
        },
        //validatePassword: function (password) {
        //    var upperCase = /[A-Z]/;
        //    if (!upperCase.test(password)) {
        //        this.errors.password.push("Password must have uppercase");
        //        this.IsValid = false;
        //    }
        //    var lowerCase = /[a-z]/;
        //    if (!lowerCase.test(password)) {
        //        this.errors.password.push("Password must have lowercase");
        //        this.IsValid = false;
        //    }
        //    var number = /[1-9]/;
        //    if (!number.test(password)) {
        //        this.errors.password.push("Password must have number");
        //        this.IsValid = false;
        //    }
        //    var symbol = /[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]/;
        //    if (!symbol.test(password)) {
        //        this.errors.password.push("Password must have a special character ex: !1/^]...");
        //        this.IsValid = false;
        //    }
        //},
        login: function () {
            this.apiErrorMessage = null;
            this.validateRequest();
            if (this.IsValid) {
                var url = "https://localhost:5001/api/auth/login";
                axios.post(url, this.loginRequest, axiosConfig)
                    .then(function (response) {

                        if (reponse.data.errors == null) {
                            localStorage.setItem("token", response.data.jwt)
                        }
                    })
                    .catch((error) => {
                        const response = error.response;
                        console.log(response.data);
                        this.apiErrorMessage = response.data;
                    })
            }
        }
    }
});




//var layout = new Vue({
//    el: 'header',
//    data: {
//        isInVisible
//    }
//})


//var selectionBoxes = new Vue({
//    el: ".paginationDiv",
//    data: {
//        ShowSelectionBoxes: false,
//    },
//    methods: {
//        ToggleShowSelectionBoxes: function () {
//            this.ShowSelectionBoxes = !this.ShowSelectionBoxes;
//        },
//    }
//});
