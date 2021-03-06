import React, * as react from 'react';
// import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { Switch, Route } from 'react-router-dom';
import { ProtectedRoutes } from './ui/routes/ProtectedRoutes';
import { PublicRoutes } from './ui/routes/PublicRoutes';
import NotFound from './ui/components/NotFound';
import  { history } from './reduxStore/store';

// eslint-disable-next-line react/prefer-stateless-function
class App extends react.Component {
	render() {
		return (
				<ConnectedRouter history={history}>
					<Switch>
						<Route exact path="/login" component={PublicRoutes} />
						<Route path="/" component={ProtectedRoutes} />
						<Route component={NotFound} />
					</Switch>
				</ConnectedRouter>
		);
	}
}

export default App;
