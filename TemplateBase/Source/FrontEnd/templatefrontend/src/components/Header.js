import React, { Component } from 'react';

class Header extends Component {

	render() {

		var logo = {
      			marginLeft: '30px',
      			marginTop: '10px'
    		};

		var menu = {
      			marginRight: '200px',
    		};

		var links = {
			'background-color': 'white',
			'color': '#008C69',
			':hover': { 'color': '#000099' }
		};


		return (
			<div>
				<div className="navbar-fixed">

    					<nav className="white nav-extended" role="navigation">
 						<div className="nav-wrapper container" style={logo}>
							<a id="logo-container" href="#!" className="brand-logo"><img src="images/main/logocabecalho.png" /></a>
						</div>

 						<div className="nav-content">
							<a href="#" data-activates="nav-mobile" className="button-collapse"><i className="material-icons">menu</i></a>
							
							<ul className="right hide-on-med-and-down" style={menu}>
          							<li><a style={{ background: "red", ":hover": { background: "green !important" } }} href="sass.html">Teste1</a></li>
          							<li><a className="link" href="badges.html">Teste2</a></li>
	      						</ul>
								
							<br />
 							<span className="right">Acesso ao Sistema</span>
							<br />
      							<a className="btn-floating btn-large halfway-fab waves-effect waves-light pulse">
        							<i className="material-icons right">send</i>
      							</a> 
    						</div>
    					</nav>

  				</div>

				<ul id="nav-mobile" className="side-nav">
					<li><a href="#">Teste1</a></li>
					<li><a href="#">Teste2</a></li>
					<li><a className="btnTeste3" data-activates="slide-out">Teste3</a></li>
					<li><a href="#">Teste4</a></li>
				</ul>

			</div>
		);
	}
}

export default Header;