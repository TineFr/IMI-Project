var baseSpeciesUrl = "https://localhost:5001/api/species?ItemsPerPage=6&Page=";
var crudUrl = "https://localhost:5001/api/species/";

const config = {
    headers: {
        Authorization: `Bearer ${localStorage.token}`,
        'Content-Type': 'multipart/form-data'
    }
};



var Species = new Vue({
    el: '#speciesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        editMode: false,
        species: null,
        mode: null,
        currentSpecies: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        isValid : true,
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
            axios.get(self.fetchUrl(), config)
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
            self.fetchSpecies();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            self.fetchSpecies();
        },

        toAddMode: function () {
            var self = this;
            self.mode = "Add new";
            self.currentSpecies = {
                name: "",
                scientificName: "",
                description: "",
            }
            self.detailMode = false
            self.overViewMode = false;
        },

        toDetailMode: function (species) {
            var self = this;
            self.overViewMode = false;
            self.detailMode = true;
            self.deleteMode = false;
            self.editMode = false;
            self.currentSpecies = species;
            self.mode = "Details";
        },
        toEditMode: function () {
            var self = this;
            self.editMode = true;
            self.detailMode = false;
            self.mode = "Edit species";
        },
        toDeleteMode: function () {
            var self = this;
            self.deleteMode = true;
            self.detailMode = false;
            self.mode = "Delete species";
        },

        backToList: function () {
            var self = this;
            self.overViewMode = true;
            self.detailMode = false
            self.deleteMode = false;
            self.editMode = false;
        },

        deleteSpecies: function () {
            var self = this;
            var url = crudUrl + self.currentSpecies.id;
            axios.delete(url, config)
                .then(function (response) {
                    self.species.forEach(function (species, i) {
                        if (species.id === self.currentSpecies.id) {
                            self.species.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })

        },
        editSpecies: function (isEditMode) {

            var self = this;
            self.validateRequest();
            if (self.isValid) {
                const formData = new FormData();
                formData.append("Name", self.currentSpecies.name);
                formData.append("ScientificName", self.currentSpecies.scientificName);
                formData.append("Description", self.currentSpecies.description);
                if (isEditMode) {
                    var url = crudUrl + self.currentSpecies.id;
                    axios.put(url, formData, config)
                        .then(function (response) {
                            self.toDetailMode(response.data);
                        })
                        .catch((error) => {
                            const response = error?.response;
                            self.apiErrorMessage = response.data;
                        })
                } else self.addSpecies(formData);

            }
        },

        addSpecies: function (data) {
            var self = this;
            var url = crudUrl;
            axios.post(url, data, config)
                .then(function () {
                    self.fetchSpecies();
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

            if (!self.currentSpecies.name) {
                self.isValid = false;
                self.errors.name.push("Name is required.");
            }
            if (!self.currentSpecies.scientificName) {
                self.isValid = false;
                self.errors.scientificName.push("Scientific Name is required.");
            }
            if (!self.currentSpecies.description) {
                self.isValid = false;
                self.errors.description.push("Description is required.");
            }
            else if (self.currentSpecies.description > 400) {
                self.isValid = false;
                self.errors.description.push("Description cannot be longer than 400 characters.");
            }
        },

        resetErrors: function () {
            this.isValid = true;
            this.errors.name = [];
            this.errors.scientificName = [];
            this.errors.description = [];
        }
    }
});