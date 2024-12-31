/* @refresh reload */
import { render } from 'solid-js/web';
import { Router, Route } from '@solidjs/router';

import './index.css';
import CategoryOverviewPage from './pages/CategoryOverviewPage';
import CategoryPage from './pages/CategoryPage';
import SubcategoryPage from './pages/SubcategoryPage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';

const root = document.getElementById('root');

if (import.meta.env.DEV && !(root instanceof HTMLElement)) {
  throw new Error(
    'Root element not found. Did you forget to add it to your index.html? Or maybe the id attribute got misspelled?',
  );
}

render(
  () => (
    <Router>
      <Route path='/' component={CategoryOverviewPage} />
      <Route path='/categorypage/:id' component={CategoryPage} />
      <Route path='/categorypage/:id/subcategorypage/:id' component={SubcategoryPage} />
      <Route path='/loginpage' component={LoginPage} />
      <Route path='/registerpage' component={RegisterPage} />
    </Router>
  ),
  document.getElementById("root")!
);
