import { createResource, createSignal, For, type Component } from 'solid-js';

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow
} from "~/components/ui/table"

import { Button } from "~/components/ui/button"

import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from "~/components/ui/dialog"

import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbSeparator
} from "~/components/ui/breadcrumb"

import { useNavigate, reload } from '@solidjs/router';

import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"

import { showToast, Toaster } from '~/components/ui/toast';

import { Flex } from '~/components/ui/flex';


const CategoryOverviewPage: Component = () => {
  const navigate = useNavigate()

  const SessionToken = String(sessionStorage.getItem("SessionToken"))
  console.log(SessionToken)
  if (SessionToken.length == 0) {
    navigate("/LoginPage")
  }

  const [categories, { refetch }] = createResource<Category[] | undefined>(() => fetch(`http://api.localhost/categories`).then(body => body.json()))
  const [newCategory, setNewCategory] = createSignal("")
  const [updatedCategory, setUpdatedCategory] = createSignal("")
  const [responseCode, setResponseCode] = createSignal(0)
  const [isOpen, setIsOpen] = createSignal(false)
  let isClosed;

  const handleOpenChange = (open: boolean) => {
    setIsOpen(open)
    isClosed = !isOpen()
    if (isClosed) {
      // Only reload when the dialog is closed
      refetch();
    }
  }

  function CreateCategory() {
    if (newCategory() !== "") {
      fetch(`http://api.localhost/categories?name=${newCategory()}`, {
        method: "POST"
      }).then((response) => {
        const statusCode = Number.parseInt(response.status.toString());
        setResponseCode(statusCode);
        switch (responseCode().toString().substring(0, 2)) {
          case "20":
            showToast({ title: "Category Added", variant: "success" })
            break;

          case "40":
            showToast({ title: "Failed!", variant: "error" })
            break;

          case "0":
            showToast({ title: "Debug", variant: "warning" })
            break;
        }
      })
    }
  }

  function UpdateCategory(categoryID: number) {
    if (updatedCategory() !== "") {
      fetch(`http://api.localhost/categories/${categoryID}?name=${updatedCategory()}`, {
        method: "PUT"
      }).then((response) => {
        const statusCode = Number.parseInt(response.status.toString());
        setResponseCode(statusCode);
        switch (responseCode().toString().substring(0, 2)) {
          case "20":
            showToast({ title: "Category Updated", variant: "success" })
            break;

          case "40":
            showToast({ title: "Failed!", variant: "error" })
            break;

          case "0":
            showToast({ title: "Debug", variant: "warning" })
            break;
        }
      })
    }
  }

  function DeleteCategory(categoryID: number) {
    if (confirm("Are you sure you want to delete this category?")) {
      fetch(`http://api.localhost/categories/${categoryID}`, {
        method: "DELETE"
      }).then(() => {
        refetch()
      })
    }
  }

  function CategoryDetails(categoryID: number) {
    sessionStorage.CategoryID = Number(categoryID)
    sessionStorage.setItem("CategoryID", categoryID.toPrecision())
    setTimeout(() => navigate(`/categorypage/${categoryID}`), 400)
  }

  function Logout() {
    sessionStorage.clear();
<<<<<<< Updated upstream
    navigate("/loginpage");
=======
    location.reload();
>>>>>>> Stashed changes
  }

  return (
    <div>
      <Flex class='p-3'>
        {/* Breadcrumb Navigation */}
        <Breadcrumb>
          <BreadcrumbList class='text-base'>
            <BreadcrumbItem>
              <BreadcrumbLink href="/" current>Home</BreadcrumbLink>
            </BreadcrumbItem>
            <BreadcrumbSeparator />
          </BreadcrumbList>
        </Breadcrumb>
        {/* --------------------- */}

        {/* Create new Category Dialog */}
        <Dialog onOpenChange={handleOpenChange}>
          <DialogTrigger><Button class={"cypressCreateCategoryButton"}>Create Category</Button></DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Create Category</DialogTitle>
              <DialogDescription> Create a new category here </DialogDescription>
            </DialogHeader>
            <div>
              <TextField>
                <TextFieldLabel>Name: </TextFieldLabel>
                <TextFieldInput class={"cypressCategoryNameInput"}
                  onChange={e => setNewCategory(e.target.value)}
                  type='text'
                  required />
              </TextField>
            </div>
            <DialogFooter>
              <Button class={"cypressCategorySubmitButton"} type='submit' onClick={() => CreateCategory()}>Create</Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
        {/* ------------------ */}

        <Button onClick={Logout}>Log out</Button>
      </Flex>

      {/* Category Table */}
      <div class="mt-5">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead class='font-bold text-black text-lg'>Name</TableHead>
              <TableHead class='font-bold text-black text-lg'>Edit</TableHead>
              <TableHead class='font-bold text-black text-lg'>Delete</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            <For each={categories()}>
              {category =>
                <TableRow class={"cypressCategoryItems"}>
                  <TableCell>
                    <Button class={"cypressCategoryItem"} variant={"link"} onClick={() => CategoryDetails(category.id)}>{category.name}</Button>
                  </TableCell>
                  <TableCell>

                    {/* Edit Category Dialog */}
                    <Dialog onOpenChange={handleOpenChange}>
                      <DialogTrigger><Button variant={'outline'} class='bg-blue-500 text-white'>Edit</Button></DialogTrigger>
                      <DialogContent>
                        <DialogHeader>
                          <DialogTitle>Update Category</DialogTitle>
                          <DialogDescription> Update category: {category.name} here </DialogDescription>
                        </DialogHeader>
                        <div>
                          <TextField>
                            <TextFieldLabel>Name: </TextFieldLabel>
                            <TextFieldInput
                              value={category.name}
                              onChange={e => setUpdatedCategory(e.target.value)}
                              type='text'
                              required />
                          </TextField>
                        </div>
                        <DialogFooter>
                          <Button type='submit' onClick={() => UpdateCategory(category.id)}>Update</Button>
                        </DialogFooter>
                      </DialogContent>
                    </Dialog>
                    {/* -------------------- */}

                  </TableCell>
                  <TableCell><Button class={"cypressCategoryItemDelete"} variant="destructive" onClick={() => DeleteCategory(category.id)}>Delete</Button></TableCell>
                </TableRow>
              }
            </For>
          </TableBody>
        </Table>
      </div>
      {/* ----------- */}

      {/* <Toaster /> */}
    </div>
  )
}

export default CategoryOverviewPage