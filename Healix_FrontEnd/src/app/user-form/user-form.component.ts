import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  userForm!: FormGroup;
  editMode: boolean = true;
  selectedUser: any;
  isEditDisabled: boolean = true;

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit(): void {
    this.loadFirstUser();
  }  

  loadFirstUser(): void {
    this.userService.getUsers().subscribe(users => {
      if (users.length > 0) {
        this.selectedUser = users[0];
        this.editMode = true;
        this.initUserForm();
        this.patchFormValues();
      } else {
        this.addBlankUser();
      }
    });
  }

  addBlankUser(): void {
    this.editMode = false;
    this.selectedUser = null;
    this.initUserForm();
  }

  initUserForm(): void {
    this.userForm = this.formBuilder.group({
      id: [null],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      mobileCountryCode: [null],
      mobileNumber: [null],
      status: [null, Validators.required]
    });
  }

  patchFormValues(): void {
    if (this.editMode && this.selectedUser) {
      this.userForm.patchValue({
        id: this.selectedUser.id,
        firstName: this.selectedUser.firstName,
        lastName: this.selectedUser.lastName,
        email: this.selectedUser.email,
        mobileCountryCode: this.selectedUser.mobileCountryCode,
        mobileNumber: this.selectedUser.mobileNumber,
        status: this.selectedUser.status
      });
    }
  }

  deleteUser(): void {
  if (this.selectedUser) {
    const confirmDelete = confirm('Are you sure you want to delete this user?');
    if (confirmDelete) {
      this.userService.deleteUser(this.selectedUser.id).subscribe(() => {
        alert('User deleted successfully');
        this.editMode = false;
        this.userForm.reset();
      });
    }
  }
}

  saveUser(): void {
    if (this.userForm.valid) {
      const user = this.userForm.value;
      if (this.editMode && this.selectedUser) {
          user.id = this.selectedUser.id;
       
        this.userService.updateUser(user).subscribe(updatedUser => {
          alert(`User updated successfully`);
          this.editMode = false;
        });
      } else {
        let userArrayLength = 0;
        this.userService.getUsers().subscribe(users => {
          userArrayLength = users.length;
        });
        user.id = userArrayLength +1;
      
        this.userService.createUser(user).subscribe(addedUser => {

          alert(`User added successfully with id ${addedUser}`);
          this.editMode = false;
        });
      }
    }
  }

  onEdit(): void {
    this.isEditDisabled = true;
    this.editMode = true;
  }

  onCancel(): void {
    this.userForm.reset();
    this.editMode = false;
    this.selectedUser = null;
  }
}
