

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

            var test = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/
            if (!test.test(password)) {
                this.errors.password.push("Password must at least have: 8 characters, one uppercase letter, one lowercase letter, one number and one special character:");
                this.IsValid = false;
            }
        },

        validateConfirmPassword: function (password) {
            if (password != this.registerRequest.password) {
                this.errors.confirmPassword.push("Confirm password must be equal to password");
                this.IsValid = false;
            }
        },

        /* register*/

        register: function () {
            this.validateRequest();
            if (this.IsValid) {
                var url = "https://localhost:5001/api/auth/register";
                axios.post(url, this.registerRequest)
                    .then(function (response) {

                            //return to login 
                       
                    })
                    .catch((error) => {

                            const response = error.response;
                            var responseMessage = response.data;
                            if (responseMessage.DuplicateEmail[0] != null) {
                                responseMessage = responseMessage.DuplicateEmail[0];
                            }
                        
                        this.apiErrorMessage = responseMessage;
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
        },

        
    }
});