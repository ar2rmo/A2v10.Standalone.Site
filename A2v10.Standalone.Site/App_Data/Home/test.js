
"use strict";

(function () {


	const http = require('std:http');


	let cm = window.$currentModule();


	const DataModelController = component('standaloneController');

	console.dir(cm);

	const vm = new DataModelController({
		el: "#page1",
		data: cm.dataModel,
		methods: {
			save() {
				vm.$save()
					.then(result => {
						console.dir('saved');
					});
			}
		}
	});

	DataModelController.init(vm, '/catalog/customer/edit', function () {
		this.$load(141);
	});

	
})();