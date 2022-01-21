
var basePrescriptionsUrl = "https://localhost:5001/api/me/prescriptions?ItemsPerPage=6&Page=";
var medicinesUrl = "https://localhost:5001/api/me/medicines";

const config = { headers: { Authorization: `Bearer ${localStorage.token}` } };

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var birds = new Vue({
    el: '#prescriptionsIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        prescriptions: null,
        mode: null,
        medicines: null,
        birds: null,
        selectedMedicine: null,
        selectedBirds: [],
        currentPrescription: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        errors: {
            name: [],
            hatchDate: [],
            gender: [],
        },

    },
    created: function () {
        var self = this;
        self.overViewMode = true;
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

        fetchUrl: function () {
            var self = this;
            var baseUri = baseBirdsUrl + self.page;
            if (self.selectedSpecies) baseUri += "&species=" + self.selectedSpecies;
            if (self.selectedCage) baseUri += "&cage=" + self.selectedCage;
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
            this.fetchBirds();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            this.fetchBirds();
        },

        toggleShowSelectionBoxes: function () {
            this.showSelectionBoxes = !this.showSelectionBoxes;
        },

        filterBirds: function () {
            var self = this;
            if (self.selectedSpecies == "All Species")
                self.selectedSpecies = null;
            if (self.selectedCage == "All Cages")
                self.selectedCage = null;
            self.fetchBirds();
        },

        toAddMode: function () {
            var self = this;
            this.mode = "Add new";
            self.currentBird = {
                name: "",
                hatchDate: "",
                food: "",
                species: "",
                cage: "",
                gender: "",
            }
            this.detailMode = false
            this.overViewMode = false;
        },

        toDetailMode: function (bird) {
            this.overViewMode = false;
            this.detailMode = true
            this.currentBird = bird;
            this.mode = "Details";
        },
        toEditMode: function () {
            this.overViewMode = false;
            this.detailMode = false
            this.mode = "Edit";
        },
    }
});
