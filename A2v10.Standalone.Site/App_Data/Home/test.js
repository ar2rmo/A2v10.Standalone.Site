
"use strict";

(function () {


	const http = require('std:http');


	let cm = window.$currentModule();

	console.dir(cm);

	const vm = new Vue({
		el: "#page1",
		data: cm.dataModel,
		methods: {
			load() {
				http.post('/data/load', JSON.stringify({ url: '/catalog/customer/edit', id:141 }))
					.then((result) => {
						this.Agent = result.Agent
					});
			}
		},
		mounted: function () {
			this.load();
		}
	});

})();