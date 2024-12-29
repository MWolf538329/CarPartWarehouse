/* @refresh reload */
import { render } from 'solid-js/web';
import {Router, Route} from '@solidjs/router';

import './index.css';
import App from './App';
import CategoryOverviewPage from '../pages/CategoryOverviewPage';
import CategoryPage from '../pages/CategoryPage';

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
      <Route path='/CategoryPage/:id' component={CategoryPage} />
    </Router>
  ),
  document.getElementById("root")!
);
