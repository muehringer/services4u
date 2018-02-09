import React, { Component } from 'react';

import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import './App.css';

import HomePage from './HomePage';



class App extends Component {
  
	render() {
    
		return (
	
<MuiThemeProvider>	
			<div>
			
				<HomePage />
		
			</div>
   
</MuiThemeProvider> 
			);
  
		  }

}



export default App;
