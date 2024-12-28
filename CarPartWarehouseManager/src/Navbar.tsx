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

import "./style.css";

const Navbar: Component = () => {
  return (
    <div>
      <div class="flex">
        <div>
          <NavigationMenu>
            <NavigationMenuItem>
              <NavigationMenuTrigger as='a' href='/'>
                Categories
              </NavigationMenuTrigger>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <NavigationMenuTrigger as='a' href='/SubcategoryPage'>
                Subcategories
              </NavigationMenuTrigger>
            </NavigationMenuItem>
          </NavigationMenu>
        </div>
      </div>

    </div>
    
  )
}

export default Navbar;
