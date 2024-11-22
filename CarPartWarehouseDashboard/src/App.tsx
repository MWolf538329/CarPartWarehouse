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

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle
} from "~/components/ui/card"
import CardComponent from './CardComponent';



//import Stock from './models/Stock';

interface Category{
  id: number;
  name: string;

  subcategories: Subcategory[];
}

interface Subcategory{
  id: number;
  name: string;
  category: Category;

  products: Product[];
}

interface Stock{
  id: number;
  currentStock: number;
  min: number;
  max: number;
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

  //const [categories] = createResource<Category[] | undefined>(() => fetch("https://localhost:42069/categories").then(body=>body.json()))
  //createEffect(() => console.log(categories()))

  //const [subcategories] = createResource<Subcategory[] | undefined>(() => fetch("https://localhost:42069/categories/subcategories").then(body=>body.json()))
  //createEffect(() => console.log(subcategories()))

  //const [products] = createResource<Product[] | undefined>(() => fetch("https://localhost:42069/products").then(body=>body.json()))
  //createEffect(() => console.log(products()))

  const [categoriesv2] = createResource<Category[] | undefined>(() => fetch("https://localhost:42069/categories/subcategories/products").then(body=>body.json()))
  createEffect(() => console.log(categoriesv2()))

  // const cards = document.querySelectorAll("Card");

  // cards.forEach(card => {
  //   const stock = parseInt(card.getAttribute("data-stock"))
  // });
  

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
      {/* Category Accordion */}
      <div>
        <For each ={categoriesv2()}>
          {category => 
          <div>
            <Accordion multiple={false} collapsible>
              <AccordionItem value="item-1">
                <AccordionTrigger> {category.name} </AccordionTrigger>
                <AccordionContent>
                  Yes. Display Subcategories!
                  
                  {/* Subcategory Accordion */}
                  <For each ={category.subcategories}>
                    {subcategory =>
                      <div>
                        <Accordion multiple={false} collapsible>
                          <AccordionItem value="item-1">
                            <AccordionTrigger> {subcategory.name} </AccordionTrigger>
                            <AccordionContent>
                              {/* Product Cards */}
                              <For each ={subcategory.products}>
                                {product => 
                                  <div>
                                    <CardComponent product={product} />

                                    {/* <Card>
                                      <CardHeader>
                                        <CardTitle>{product.name}</CardTitle>
                                      </CardHeader>
                                      <CardContent>
                                        <p>Current: {product.stock.currentStock} - Min: {product.stock.min} - Max: {product.stock.max}</p>
                                      </CardContent>
                                    </Card> */}
                                  </div>
                                }
                              </For>
                              {/* -------------------------------------------------------------------------------- */}
                            </AccordionContent>
                          </AccordionItem>
                        </Accordion>
                      </div>
                    }
                  </For>
                  {/* -------------------------------------------------------------------------------- */}
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
