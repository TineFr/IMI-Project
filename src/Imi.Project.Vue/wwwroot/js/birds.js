
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
            self.apiErrorMessage = null;
            test.get(birdsUrl + self.page, config)
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

        ToggleShowSelectionBoxes: function () {
            this.ShowSelectionBoxes = !this.ShowSelectionBoxes;
        },

        //FilterCages: function (cage) {
        //    var self = this;
        //    this.CurrentPage = 1;
        //    self.apiErrorMessage = null;
        //    var url = birdsUrl + this.CurrentPage + "&cageId=" + cage ;
        //    axios.get(url, config)
        //        .then(function (response) {
        //            self.cages = response.data;
        //        })
        //        .catch((error) => {
        //            const response = error?.response;
        //            this.apiErrorMessage = response.data;
        //        })
        //},

        ManagePagination(data) {
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

        onNextPageClicked() {
            var self = this;
            self.page += 1;
            this.fetchBirds();
        },

        onPreviousPageClicked() {
            var self = this;
            self.page -= 1;
            this.fetchBirds();
        }

    }

});

/*https://localhost:5001/api/me/birds?ItemsPerPage=6&Page=1&speciesId=00000000-0000-0000-0000-000000000001&cageId=00000000-0000-0000-0000-000000000003*/