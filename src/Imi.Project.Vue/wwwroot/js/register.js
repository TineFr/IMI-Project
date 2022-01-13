var register = new Vue({
    el: '#divRegister',
    data: {
        registerRequest: {
            name: "",
            firstName: "",
            dateOfBirth: "",
            email: "",
            password: "",
            confirmPassword: "",
        },
        errors: {
            password: [],
            email: [],
            firstName: [],
            name: [],
            dateOfBirth: [],
            confirmPassword: [],
        },
        IsValid: true,
        apiErrorMessage: null,
    },
    methods: {

        validateRequest: function () {
            this.resetErrors();

            if (!this.registerRequest.email) {
                this.IsValid = false;
                this.errors.email.push("Email is required.");
            } else this.validateEmail(this.registerRequest.email);

            if (!this.registerRequest.name) {
                this.IsValid = false;
                this.errors.name.push("Name is required.");
            }

            if (!this.registerRequest.firstName) {
                this.IsValid = false;
                this.errors.firstName.push("First Name is required.");
            }

            if (!this.registerRequest.dateOfBirth) {
                this.IsValid = false;
                this.errors.dateOfBirth.push("Date Of Birth is required.");
            } else this.validateDateOfBirth(this.registerRequest.dateOfBirth);

            if (!this.registerRequest.password) {
                this.IsValid = false;
                this.errors.password.push("Password is required.");
            } else this.validatePassword(this.registerRequest.password);

            if (!this.registerRequest.confirmPassword) {
                this.IsValid = false;
                this.errors.confirmPassword.push("Confirm Password is required.");
            } else this.validateConfirmPassword(this.registerRequest.confirmPassword);
        },

        /* validations*/

        validateEmail: function (email) {
            var regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!regex.test(email)) {
                this.errors.email.push("Not a valid e-mail adress");
                this.IsValid = false;
            }
        },

        validateDateOfBirth: function (date) {
            var Startdate = new Date(date)
            var now = new Date();
            if (Startdate > now) {
                this.errors.dateOfBirth.push("Date of birth cannot be a future date");
                this.IsValid = false;
            }
        },
        validatePassword: function (password) {
            var upperCase = /[A-Z]/;
            if (!upperCase.test(password)) {
                this.errors.password.push("Password must have uppercase");
                this.IsValid = false;
            }
            var lowerCase = /[a-z]/;
            if (!lowerCase.test(password)) {
                this.errors.password.push("Password must have lowercase");
                this.IsValid = false;
            }
            var number = /[1-9]/;
            if (!number.test(password)) {
                this.errors.password.push("Password must have number");
                this.IsValid = false;
            }
            var symbol = /[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]/;
            if (!symbol.test(password)) {
                this.errors.password.push("Password must have a special character ex: !1/^]...");
                this.IsValid = false;
            }
        },

        validateConfirmPassword: function (password) {
            if (password != this.loginRequest.password) {
                this.errors.password.push("Confirm password must be equal to password");
                this.IsValid = false;
            }
        },

        /* register*/

        register: function () {
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
        },

        resetErrors: function () {
            this.IsValid = true;
            this.errors.password = [];
            this.errors.email = [];
            this.errors.confirmPassword = [];
            this.errors.dateOfBirth = [];
            this.errors.name = [];
            this.errors.firstName = [];
            this.apiErrorMessage = null;
        }
    }
});