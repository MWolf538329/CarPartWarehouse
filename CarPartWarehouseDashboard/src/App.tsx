import { createEffect, createResource, For, Show, type Component } from 'solid-js';
//import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
//import { createResource, createSignal, For } from 'solid-js';
import { Flex } from './components/ui/flex';
import { Switch, SwitchControl, SwitchLabel, SwitchThumb } from './components/ui/switch';
import { TextField, TextFieldInput, TextFieldLabel } from './components/ui/text-field';
import Navbar from './Navbar';

import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger
} from "~/components/ui/accordion"



//import Stock from './models/Stock';

interface Category{
  id: number;
  name: string;
}

interface Subcategory{
  id: number;
  name: string;
  category: Category;
}

interface Stock{
  id: number;
  currentstock: number;
  minstock: number;
  maxstock: number;
}

interface Product{
  id: number;
  name: string;
  stock: Stock;
  subcategory: Subcategory;
}

const App: Component = () => {
  //const [weatherLocation, setWeatherLocation] = createSignal('London')
  //const [weather] = createResource(weatherLocation, (location) => fetch(`/api/weatherforecast?location=${location}`).then(res => res.json()))

  // const [TableData, SetTableData] = createSignal()
  // const [stockData] = createResource(() => fetch('stocks').then(result => result.json()))

  const [categories] = createResource<Category[] | undefined>(() => fetch("https://localhost:42069/categories").then(body=>body.json()))
  createEffect(() => console.log(categories()))

  const [subcategories] = createResource<Subcategory[] | undefined>(() => fetch("https://localhost:42069/categories/subcategories").then(body=>body.json()))
  createEffect(() => console.log(subcategories()))

  const [products] = createResource<Product[] | undefined>(() => fetch("https://localhost:42069/products").then(body=>body.json()))
  createEffect(() => console.log(products()))
  

  // async function FetchStockData(params:Stock) : Promise<Stock[]> {
  //   const stockItems:Stock[] = [];

  //   try {
  //     const response = await fetch('https://localhost:42069/stocks');
  //     if(!response.ok){
  //       throw new Error("Failed to fetch stock items");
  //     }

  //     return await response.json();

  //   } catch (error) {
  //     console.error("Error fetching stock names:", error);
  //     return [];
  //   }
  // }

  return (
    <div>
{/* <Flex flexDirection='col' alignItems='center' justifyContent='center' class="gap-2 my-2">

{/* ------------ Page Title on the top left and Navbar in the top middle ------------ */}
{/* <Flex flexDirection='row' alignItems='center' justifyContent='start'>
  <h1>CarPartWarehouse Dashboard</h1>

  <Flex flexDirection='row' alignItems='center' justifyContent='center'>
    <Navbar/>
  </Flex>
</Flex>
</Flex> */}
{/* -------------------------------------------------------------------------------- */}

{/* <p>{stockData()}</p> */}


      {/* Accordion with Stock Data */}
      <div>
        <For each ={categories()}>
          {category => 
          <div>
            <Accordion multiple={false} collapsible>
              <AccordionItem value="item-1">
                <AccordionTrigger> {category.name} </AccordionTrigger>
                <AccordionContent>
                  Yes. Display Subcategories!
                  
                  {/* Subcategory Accordion */}
                  <For each ={subcategories()}>
                    {subcategory =>                       
                      <div>
                        
                      </div>
                    }
                  </For>

                  </AccordionContent>
              </AccordionItem>
            </Accordion>
          </div>
          }
        </For>
      </div>
      {/* -------------------------------------------------------------------------------- */}

    </div>
  );
};

export default App;
