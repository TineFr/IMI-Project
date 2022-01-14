
var url = "https://localhost:5001/api/me/birds";
const config = { headers: { Authorization: `Bearer ${localStorage.token}` } };



var login = new Vue({
    el: '#birdsIndex',
    data: {
        birds: null,
        currentBird : null,
        errors: {
            password: [],
            email: []
        },
        apiErrorMessage: null,
    },
    created: function () {
        var self = this;
        self.fetchBirds();
    },

    methods: {

        fetchBirds: function () {
            var self = this;
            self.apiErrorMessage = null;
            axios.get(url, config)
                .then(function (response) {

                    self.birds = response.data;
                    console.log(self.birds[0])

                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
            }
        }
});