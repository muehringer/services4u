import React, {Component} from 'react';
import $ from 'jquery';

class Body extends Component {

	constructor(props) {
    		super(props);
    		this.state = {user: '', password: ''};
		debugger;
		//usar no botão ou aqui no construtor
		this.login = this.login.bind(this); 
		this.loginChange = this.loginChange.bind(this);
	}

	loginChange(event) {
		this.setState({user: event.target.form.user.value, password: event.target.form.password.value});
	}

	login(event) {

		var token = null;
		var token_type = null;

		$.ajax({
			  method: "POST",
			  url: "http://localhost:12004/token",
			  //data: { username: "Fulano", password: "1234", grant_type: "password" }, 
			  data: { username: this.state.user, password: this.state.password, grant_type: "password" }, 
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
                
			  }
		});

		event.preventDefault();
	}

	render() {
		return (
			<div>
				<span>Corpo</span>
				<div className="row">
					<form className="col s12">
						<div className="input-field col s6">
							  <input placeholder="User" id="user" type="text" className="validate" value={this.state.user} onChange={this.loginChange} />
							  <label htmlFor="user">User</label>
						</div>
						<div className="input-field col s6">
							  <input placeholder="Password" id="password" type="password" className="validate" value={this.state.password} onChange={this.loginChange} />
							  <label htmlFor="password">Password</label>
						</div>

						<button className="btn waves-effect waves-light" onClick={this.login} type="button" name="action">Login
							<i className="material-icons right">send</i>
						</button>
					</form>
				</div>
		
			</div>
		);
	}
}

export default Body;