var baseSpeciesUrl = "https://localhost:5001/api/species?ItemsPerPage=6&Page=";

const config = { headers: { Authorization: `Bearer ${localStorage.token}` } };

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var cages = new Vue({
    el: '#speciesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        species: null,
        mode: null,
        currentSpecies: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        errors: {
            name: [],
            description: [],
            scientificName: [],
        },

    },
    created: function () {
        var self = this;
        self.overViewMode = true;
        self.fetchSpecies(this.CurrentPage);
    },

    methods: {

        fetchSpecies: function () {
            var self = this;
            self.species = null;
            self.apiErrorMessage = null;
            test.get(self.fetchUrl(), config)
                .then(function (response) {
                    self.species = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        },
        fetchUrl: function () {
            var self = this;
            var baseUri = baseSpeciesUrl + self.page;
            return baseUri
        },

        ManagePagination: function (data) {
            var self = this;
            self.page = data.CurrentPage;
            self.hasNextPage = false;
            self.hasPreviousPage = false;
            if (data.HasPreviousPage == true) {
                self.hasPreviousPage = true;
            }
            if (data.HasNextPage == true) {
                self.hasNextPage = true;
            }
        },

        onNextPageClicked: function () {
            var self = this;
            self.page += 1;
            this.fetchSpecies();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            this.fetchSpecies();
        },

        toAddMode: function () {
            var self = this;
            this.mode = "Add new";
            self.currentCage = {
                name: "",
                scientificName: "",
                description: "",

            }
            this.detailMode = false
            this.overViewMode = false;
        },

        toDetailMode: function (species) {
            this.overViewMode = false;
            this.detailMode = true
            this.currentSpecies = species;
            this.mode = "Details";
        },
        toEditMode: function () {
            this.overViewMode = false;
            this.detailMode = false
            this.mode = "Edit species";
        },
    }
});