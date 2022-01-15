var baseMedicinesUrl = "https://localhost:5001/api/me/medicines?ItemsPerPage=6&Page=";
var crudUrl = "https://localhost:5001/api/medicines/";

const config = {
    headers: { Authorization: `Bearer ${localStorage.token}`}
};

var test = axios.create({
    allowedHeaders: ['pagination'],
});


var medicines = new Vue({
    el: '#medicinesIndex',
    data: {
        overViewMode: true,
        detailMode: false,
        deleteMode: false,
        editMode: false,
        medicines: null,
        mode: null,
        currentMedicine: null,
        apiErrorMessage: null,
        page: 1,
        hasNextPage: false,
        hasPreviousPage: false,
        isValid: true,
        errors: {
            name: [],
            usage: [],
        },

    },
    created: function () {
        var self = this;
        self.overViewMode = true;
        self.fetchMedicines(this.page);
    },

    methods: {

        fetchMedicines: function () {
            var self = this;
            self.medicines = null;
            self.apiErrorMessage = null;
            test.get(self.fetchBaseUrl(), config)
                .then(function (response) {
                    self.medicines = response.data;
                    self.ManagePagination(JSON.parse(response.headers.pagination))
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })
        },
        fetchBaseUrl: function () {
            var self = this;
            var baseUri = baseMedicinesUrl + self.page;
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
            this.fetchMedicines();
        },

        onPreviousPageClicked: function () {
            var self = this;
            self.page -= 1;
            this.fetchMedicines();
        },

        toAddMode: function () {
            var self = this;
            this.mode = "Add new";
            self.currentMedicine = {
                name: "",
                usage: "",
            }
            this.detailMode = false
            this.overViewMode = false;
        },

        toDetailMode: function (medicine) {
            this.overViewMode = false;
            this.detailMode = true;
            this.deleteMode = false;
            this.editMode = false;
            this.currentMedicine = medicine;
            this.mode = "Details";
        },
        toEditMode: function () {
            this.editMode = true;
            this.detailMode = false;
            this.mode = "Edit medicine";
        },
        toDeleteMode: function () {
            this.deleteMode = true;
            this.detailMode = false;
            this.mode = "Delete medicine";
        },

        backToList: function () {
            this.overViewMode = true;
            this.detailMode = false
            this.deleteMode = false;
            this.editMode = false;
        },

        deleteMedicine: function () {
            var self = this;
            var url = crudUrl + self.currentMedicine.id;
            axios.delete(url, config)
                .then(function (response) {
                    self.medicines.forEach(function (medicine, i) {
                        if (medicine.id === self.currentMedicine.id) {
                            self.medicines.splice(i, 1);
                        }
                    });
                    self.backToList();
                })
                .catch((error) => {
                    const response = error?.response;
                    this.apiErrorMessage = response.data;
                })

        },
        editMedicine: function (isEditMode) {

            var self = this;
            self.validateRequest();
            if (self.isValid) {
                if (isEditMode) {
                    var url = crudUrl + self.currentMedicine.id;
                    axios.put(url, self.currentMedicine, config)
                        .then(function (response) {
                            self.toDetailMode(response.data);
                        })
                        .catch((error) => {
                            const response = error?.response;
                            self.apiErrorMessage = response.data;
                        })
                } else this.addMedicine();

            }
        },

        addMedicine: function () {
            var self = this;
            var url = crudUrl;
            axios.post(url, self.currentMedicine, config)
                .then(function (response) {
                    self.fetchMedicines();
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

            if (!self.currentMedicine.name) {
                self.isValid = false;
                self.errors.name.push("Name is required.");
            }
            if (!self.currentMedicine.usage) {
                self.isValid = false;
                self.errors.location.push("Usage is required.");
            }
        },

        resetErrors: function () {
            this.isValid = true;
            this.errors.name = [];
            this.errors.usage = [];
        }
    }
});
