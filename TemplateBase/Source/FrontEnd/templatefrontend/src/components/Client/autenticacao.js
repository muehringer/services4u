var token = null;
var token_type = null;

$(document).ready(function () {

//Autentica e pega o token
$.ajax({
  method: "POST",
  url: "http://localhost:13874/token",
  data: { username: "Fulano", password: "1234", grant_type: "password" }, 
  headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
  contentType: "application/json; charset=utf-8",
  dataType: 'json',
  async: false,
  beforeSend : function(){
               //$("#resultado").html("ENVIANDO...");
	      },
  success: function (response) {
debugger;

token = response.access_token;
token_type = response.token_type;
  },
  error: function (e) {
debugger;
                $.msgBox({
                    title: "Atenção",
                    type: "error",
                    content: "Ocorreu um erro inesperado. Entre em contato com o administrador."
                });
   }
});


//acessa servico e usa o token
$.ajax({
  method: "GET",
  url: "http://localhost:13874/api/teste",
  headers: { 'Authorization': token_type + ' ' + token},
  contentType: "application/json; charset=utf-8",
  dataType: 'json',
  success: function (response) {
debugger;


  },
  error: function (e) {
debugger;
                $.msgBox({
                    title: "Atenção",
                    type: "error",
                    content: "Ocorreu um erro inesperado. Entre em contato com o administrador."
                });
   }
});

});