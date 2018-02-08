import $ from 'jquery';

export const getToken = (username, password) => {
		var token = null;
		var token_type = null;

		$.ajax({
			  method: "POST",
			  url: "http://localhost:12004/token",
			  //data: { username: "Fulano", password: "1234", grant_type: "password" }, 
			  data: { username: username, password: password, grant_type: "password" }, 
			  //headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
			  contentType: "application/json; charset=utf-8",
			  dataType: 'json',
			  async: false,
			  beforeSend : function(){
						   //$("#resultado").html("ENVIANDO...");
			  },
			  success: function (response) {
				token = response.access_token;
				token_type = response.token_type;
			  },
			  error: function (e) {
                		debugger;
			  }
		});

		return token;
	}