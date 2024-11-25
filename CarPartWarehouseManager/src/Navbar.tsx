import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { createResource, createSignal, For } from 'solid-js';
 
import type { Orientation } from "@kobalte/core/navigation-menu"
 
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuDescription,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLabel,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"
import { Flex } from './components/ui/flex';

const Navbar: Component = () => {
  const [weatherLocation, setWeatherLocation] = createSignal('London')
  const [weather] = createResource(weatherLocation, (location) => fetch(`/api/weatherforecast?location=${location}`).then(res => res.json()))

  return (
    <div class="flex flex-col items-center space-y-4">
      <NavigationMenu>
        <NavigationMenuItem>

          <NavigationMenuTrigger>
            Categories
          </NavigationMenuTrigger>

          <NavigationMenuTrigger>
            Subcategories
          </NavigationMenuTrigger>
          
        </NavigationMenuItem>
      </NavigationMenu>
    </div>
  )
}

export default Navbar;
