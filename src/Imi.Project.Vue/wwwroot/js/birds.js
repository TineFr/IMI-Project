
var birdsUrl = "https://localhost:5001/api/me/birds?ItemsPerPage=6&Page=";
var speciesUrl = "https://localhost:5001/api/species";
var cagesUrl = "https://localhost:5001/api/me/cages";
const config = { headers: { Authorization: `Bearer ${localStorage.token}` } };

var test = axios.create({
    allowedHeaders: ['pagination'],
});



var login = new Vue({
    el: '#birdsIndex',
    data: {
        birds: null,
        species: null,
        cages: null,
        currentBird : null,
        errors: {
            password: [],
            email: []
        },
        apiErrorMessage: null,
        ShowSelectionBoxes: false,
        CurrentPage: 1,
        HasNextPage: false,

    },
    created: function () {
        var self = this;
        self.fetchBirds(this.CurrentPage);
        self.fetchSpecies();
        self.fetchCages();
    },

    methods: {

        fetchBirds: function (page) {
            var self = this;
            self.apiErrorMessage = null;
            test.get(birdsUrl + page, config)
                .then(function (response) {
                    self.birds = response.data;
                    var test = response.request.getResponseHeader('pagination');
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        },

        fetchSpecies: function () {
            var self = this;
            self.apiErrorMessage = null;
            axios.get(speciesUrl, config)
                .then(function (response) {
                    self.species = response.data;
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })

        },
        fetchCages: function () {
            var self = this;
            self.apiErrorMessage = null;
            axios.get(cagesUrl, config)
                .then(function (response) {
                    self.cages = response.data;
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })

        },

        ToggleShowSelectionBoxes: function () {
            this.ShowSelectionBoxes = !this.ShowSelectionBoxes;
        },

        FilterCages: function (cage) {
            var self = this;
            this.CurrentPage = 1;
            self.apiErrorMessage = null;
            var url = birdsUrl + this.CurrentPage + "&cageId=" + cage ;
            axios.get(url, config)
                .then(function (response) {
                    self.cages = response.data;
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        }

    }

});

/*https://localhost:5001/api/me/birds?ItemsPerPage=6&Page=1&speciesId=00000000-0000-0000-0000-000000000001&cageId=00000000-0000-0000-0000-000000000003*/