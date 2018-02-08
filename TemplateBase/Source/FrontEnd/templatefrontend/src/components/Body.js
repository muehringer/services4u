import React, {Component} from 'react';
import { getToken } from '../api/GetToken'
	
class Body extends Component {

	constructor(props) {
    		super(props);
    		this.state = {user: '', password: '', tokenX: ''};
		//usar no botão ou aqui no construtor
		this.login = this.login.bind(this); 
		this.loginChange = this.loginChange.bind(this);
	}

	loginChange(event) {
		this.setState({user: event.target.form.user.value, password: event.target.form.password.value});
	}
        	
	login(event) {
		this.state.tokenX = getToken(this.state.user, this.state.password);
		event.preventDefault();
	}

	render() {
		return (
			<div>
				<span>Corpo</span>
				<div className="row">
					<form className="col s12">
						<div className="input-field col s3">
							  <input placeholder="User" id="user" type="text" className="validate" value={this.state.user} onChange={this.loginChange} />
							  <label htmlFor="user">User</label>
						</div>
						<div className="input-field col s3">
							  <input placeholder="Password" id="password" type="password" className="validate" value={this.state.password} onChange={this.loginChange} />
							  <label htmlFor="password">Password</label>
						</div>
						<div className="input-field col s6">
						</div>				
						<div className="col s12">
						<button className="btn waves-effect waves-light" onClick={this.login} type="button" name="action">Login
							<i className="material-icons right">send</i>
						</button>
						</div>
					</form>
				</div>
				<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
		
			</div>
		);
	}
}

export default Body;