
var baseBirdsUrl = "https://localhost:5001/api/me/birds?ItemsPerPage=6&Page=";
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
        selectedSpecies: null,
        selectedCage: null,
        currentBird : null,
        apiErrorMessage: null,
        showSelectionBoxes: false,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,

    },
    created: function () {
        var self = this;
        self.fetchBirds(this.CurrentPage);
        self.fetchSpecies();
        self.fetchCages();
    },

    methods: {

        fetchBirds: function () {
            var self = this;
            self.birds = null;
            self.apiErrorMessage = null;
            test.get(self.fetchUrl(), config)
                .then(function (response) {
                    self.birds = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
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

        toggleShowSelectionBoxes: function () {
            this.showSelectionBoxes = !this.showSelectionBoxes;
        },

        ManagePagination: function(data) {
            var self = this;
            self.page = 1;
            self.hasNextPage = false;
            self.hasPreviousPage = false;
            if (data.HasPreviousPage == true) {
                self.hasPreviousPage = true;
            }
            if (data.HasNextPage == true) {
                self.hasNextPage = true;
            }
        },

        onNextPageClicked: function() {
            var self = this;
            self.page += 1;
            this.fetchBirds();
        },

        onPreviousPageClicked: function() {
            var self = this;
            self.page -= 1;
            this.fetchBirds();
        },

        fetchUrl: function () {
            var self = this;
            var baseUri = baseBirdsUrl + self.page;
            if (self.selectedSpecies) baseUri += "&species=" + self.selectedSpecies;
            if (self.selectedCage) baseUri += "&cage=" + self.selectedCage;
            return baseUri
        },

        filterBirds: function () {
            var self = this;
            if (self.selectedSpecies == "All Species")
                self.selectedSpecies = null;
            if (self.selectedCage == "All Cages")
                self.selectedCage = null;
            self.fetchBirds();
        }
    }
});

