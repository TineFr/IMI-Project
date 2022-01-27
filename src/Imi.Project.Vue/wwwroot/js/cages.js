var baseUrl = "https://localhost:5001/api/me/cages?ItemsPerPage=6&Page=";
var crudUrl = "https://localhost:5001/api/cages/";

const config = {
    headers: {
        Authorization: `Bearer ${sessionStorage.token}`,
       'Content-Type': 'multipart/form-data'
    }
};

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var cages = new Vue({
    el: '#cagesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        deleteMode: false,
        editMode : false,
        cages: null,
        mode: null,
        currentCage: null,
        apiErrorMessage: null,
        page: 1,
        newImage: null,
        hasNextPage: false,
        hasPreviousPage: false,
        isValid: true,
        errors: {
            name: [],
            location: [],
        },

    },
    created: function () {
        var self = this;
        self.fetchCages(this.page);
    },

    methods: {

        fetchCages: function () {
            var self = this;
            self.cages = null;
            self.apiErrorMessage = null;
            test.get(self.fetchBaseUrl(), config)
                .then(function (response) {
                    self.cages = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    if (response.data.startsWith('No')) {
                        self.apiErrorMessage = "No cages found";
                    }
                    else self.apiErrorMessage = response.data;
                })
        },
        fetchBaseUrl: function () {
            var self = this;
            var url = baseUrl + self.page;
            return url
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
            self.fetchCages();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            self.fetchCages();
        },

        toAddMode: function () {
            var self = this;
            self.mode = "Add new";
            self.apiErrorMessage = null
            self.overViewMode = false;
            self.currentCage = {
                name: "",
                location: "",
            }
        },

        toDetailMode: function (cage) {
            var self = this;
            self.resetErrors();
            self.apiErrorMessage = null
            self.overViewMode = false;
            self.detailMode = true;
            self.deleteMode = false;
            self.editMode = false;
            self.currentCage = cage;
            self.mode = "Details";
        },
        toEditMode: function () {
            var self = this;
            self.editMode = true;
            self.detailMode = false;
            self.mode = "Edit cage";
        },
        toDeleteMode: function () {
            var self = this;
            self.deleteMode = true;
            self.detailMode = false;
            self.mode = "Delete cage";
        },

        backToList: function () {
            var self = this;
            self.resetErrors();
            self.fetchCages();
            self.overViewMode = true;
            self.detailMode = false
            self.deleteMode = false;
            self.editMode = false;
        },

        deleteCage: function () {
            var self = this;
            var url = crudUrl + self.currentCage.id;
            axios.delete(url, config)
                .then(function (response) {
                    self.cages.forEach(function (cage, i) {
                        if (cage.id === self.currentCage.id) {
                            self.cages.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    self.apiErrorMessage = response.data;
                })
            
        },
        editCage: function (isEditMode) {

            var self = this;
            self.validateRequest();
            if (self.isValid) {
                const formData = new FormData();
                formData.append("Name", self.currentCage.name);
                formData.append("Location", self.currentCage.location);
                if (self.newImage) formData.append("Image", self.newImage);
                if (isEditMode) {
                    var url = crudUrl + self.currentCage.id;
                    axios.put(url, formData, config)
                        .then(function (response) {
                            self.toDetailMode(response.data);
                        })
                        .catch((error) => {
                            const response = error?.response;
                            self.apiErrorMessage = response.data;
                        })
                } else self.addCage(formData);

            }
        },

        addCage: function (data) {
            var self = this;
            var url = crudUrl;
            axios.post(url, data, config)
                .then(function (response) {
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

            if (!self.currentCage.name) {
                self.isValid = false;
                self.errors.name.push("Name is required.");
            }
            else if (self.currentCage.name.length > 20) {
                self.isValid = false;
                self.errors.name.push("Name cannot be longer than 25 characters.");
            }
            if (!self.currentCage.location) {
                self.isValid = false;
                self.errors.location.push("Location is required.");
            }
            else if (self.currentCage.name.length > 20) {
                self.isValid = false;
                self.errors.location.push("Location cannot be longer than 25 characters.");
            }
        },

        resetErrors: function () {
            var self = this;
            self.isValid = true;
            self.errors.name = [];
            self.errors.location = [];
        },

        uploadImage(e) {
            var self = this;
            const image = e.target.files[0];
            self.newImage = image;
        },

        cancelClicked: function () {
            var self = this
            if (self.editMode || self.deleteMode) {
                self.toDetailMode(self.currentCage);
            }
            else self.backToList();
        }
    }
});
