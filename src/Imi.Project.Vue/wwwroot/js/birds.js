
var baseUrl = "https://localhost:5001/api/me/birds?ItemsPerPage=6&Page=";
var speciesUrl = "https://localhost:5001/api/species?ItemsPerPage=1000";
var cagesUrl = "https://localhost:5001/api/me/cages?ItemsPerPage=1000";
var crudUrl = "https://localhost:5001/api/birds/";

const config = {
    headers: {
        Authorization: `Bearer ${sessionStorage.token}`,
        'Content-Type': 'multipart/form-data'
    }
};

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var birds = new Vue({
    el: '#birdsIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        deleteMode: false,
        editMode: false,
        addMode: false,
        birds: null,
        mode: null,
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
        isValid: true,
        newImage : null,
        errors: {
            name: [],
            hatchDate: [],
            gender: [],
        },

    },
    created: function () {
        var self = this;
        self.overViewMode = true;
        self.fetchBirds(self.page);
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
                    if (response.data.startsWith('No')) {
                        self.apiErrorMessage = "No birds found";
                    }
                    else self.apiErrorMessage = response.data;
                })
        },

        fetchSpecies: function () {
            var self = this;
            self.apiErrorMessage = null;
            axios.get(speciesUrl, config)
                .then(function (response) {
                    self.species = response.data;
                })
        },
        fetchCages: function () {
            var self = this;
            self.apiErrorMessage = null;
            axios.get(cagesUrl, config)
                .then(function (response) {
                    self.cages = response.data;
                })
        },

        fetchUrl: function () {
            var self = this;
            var url = baseUrl + self.page;
            if (self.selectedSpecies) url += "&species=" + self.selectedSpecies;
            if (self.selectedCage) url += "&cage=" + self.selectedCage;
            return url
        },


        ManagePagination: function(data) {
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

        onNextPageClicked: function() {
            var self = this;
            self.page += 1;
            self.fetchBirds();
        },

        onPreviousPageClicked: function() {
            var self = this;
            self.page -= 1;
            self.fetchBirds();
        },

        toggleShowSelectionBoxes: function () {
            var self = this;
            self.showSelectionBoxes = !self.showSelectionBoxes;
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
            self.apiErrorMessage = null;
            self.addMode = true;
            self.detailMode = false;
            self.overViewMode = false;
            self.mode = "Add new";
            self.currentBird = {
                name: "",
                hatchDate: "",
                food : "",
                species : "",
                cage : ""
            }

        },

        toDetailMode: function (bird) {
            var self = this;
            self.resetErrors();
            self.apiErrorMessage = null;
            self.overViewMode = false;
            self.detailMode = true;
            self.deleteMode = false;
            self.editMode = false;
            self.currentBird = bird;
            self.mode = "Details";
        },
        toEditMode: function () {
            var self = this;
            self.editMode = true;
            self.detailMode = false;
            self.mode = "Edit bird";
        },
        toDeleteMode: function () {
            var self = this;
            self.deleteMode = true;
            self.detailMode = false;
            self.mode = "Delete bird";
        },

        backToList: function () {
            var self = this;
            self.addMode = false;
            self.resetErrors();
            self.fetchBirds();
            self.overViewMode = true;
            self.detailMode = false
            self.deleteMode = false;
            self.editMode = false;
        },

        deleteBird: function () {
            var self = this;
            var url = crudUrl + self.currentBird.id;
            axios.delete(url, config)
                .then(function () {
                    self.birds.forEach(function (bird, i) {
                        if (bird.id === self.currentBird.id) {
                            self.birds.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })

        },
        editBird: function (isEditMode) {

            var self = this;
            self.validateRequest();
            if (self.isValid) {
                const formData = new FormData();
                formData.append("Name", self.currentBird.name);
                formData.append("HatchDate", self.currentBird.hatchDate);
                if (self.currentBird.cage) formData.append("CageId", self.currentBird.cage.id);
                if (self.currentBird.species) formData.append("SpeciesId", self.currentBird.species.id);
                if (self.currentBird.food) formData.append("Food", self.currentBird.food);
                if (self.newImage) formData.append("Image", self.newImage);
                if (isEditMode) {
                    var url = crudUrl + self.currentBird.id;
                    axios.put(url, formData, config)
                        .then(function (response) {
                            self.toDetailMode(response.data);
                        })
                        .catch((error) => {
                            const response = error?.response;
                            self.apiErrorMessage = response.data;
                        })
                } else self.addBird(formData);

            }
        },

        addBird: function (data) {
            var self = this;
            var url = crudUrl;
            axios.post(url, data, config)
                .then(function () {
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })
        },

        validateRequest: function () {

            var self = this;
            self.resetErrors();

            if (!self.currentBird.name) {
                self.isValid = false;
                self.errors.name.push("Name is required.");
            }
            else if (self.currentBird.name.length > 15) {
                self.isValid = false;
                self.errors.name.push("Name cannot be longer than 15 characters.");
            }
            if (!self.currentBird.hatchDate) {
                self.isValid = false;
                self.errors.hatchDate.push("Hatch Date is required.");
            }
            else {
                var Startdate = new Date(self.currentBird.hatchDate)
                var now = new Date();
                if (Startdate > now) {
                    self.errors.hatchDate.push("Hatch Date cannot be a future date");
                    self.isValid = false;
                }              
            }
        },

        resetErrors: function () {
            var self = this;
            self.isValid = true;
            self.errors.name = [];
            self.errors.hatchDate = [];
            self.errors.gender = [];
        },

        uploadImage(e) {
            var self = this;
            const image = e.target.files[0];
            self.newImage = image;
        },

        cancelClicked : function () {
            var self = this
            if (self.editMode || self.deleteMode) {
                self.toDetailMode(self.currentBird);
            }
            else self.backToList();
        }
    }
});




