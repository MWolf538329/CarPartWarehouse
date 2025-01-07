import { createEffect, createResource, type Component } from 'solid-js';

const App: Component = () => {

  const [categoriesv2] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories/subcategories/products").then(body => body.json()))
  createEffect(() => console.log(categoriesv2()))

  return (
    <div>
    </div>
  );
};

export default App;
