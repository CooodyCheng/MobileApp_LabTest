namespace MobileApp_LabTest;

public partial class Question2 : ContentPage
{
	public Question2()
	{
		InitializeComponent();

        PhoneEntry.TextChanged += PhoneEntry_TextChanged;
        PasswordEntry.TextChanged += PasswordEntry_TextChanged;
        TermsAndConditionCheckbox.CheckedChanged += TermsAndConditionCheckbox_CheckedChanged;

        //// Attach validation behaviors
        //PhoneEntry.Behaviors.Add(new NumericValidationBehavior());
        //PasswordEntry.Behaviors.Add(new MinLengthValidationBehavior(6));

        //// Additional setup for checkbox click
        //var tapGestureRecognizer = new TapGestureRecognizer();
        //tapGestureRecognizer.Tapped += (s, e) => TermsAndConditionCheckbox.IsChecked = !TermsAndConditionCheckbox.IsChecked;
        //TermsAndConditionsLabel.GestureRecognizers.Add(tapGestureRecognizer);

        //// Set up MultiTrigger for button
        //var multiTrigger = new MultiTrigger
        //{
        //    Triggers =
        //    {
        //        new Trigger
        //        {
        //            Property = CheckBox.IsCheckedProperty,
        //            Value = true
        //        },
        //        new Trigger
        //        {
        //            Property = Entry.TextProperty,
        //            Condition = new IsNotNullOrEmptyCondition(),
        //            Value = true
        //        },
        //        new Trigger
        //        {
        //            Property = PasswordEntry.TextProperty,
        //            Condition = new IsNotNullOrEmptyCondition(),
        //            Value = true
        //        }
        //    }
        //};

        //// Enable the button when all conditions are met
        //RegisterButton.Triggers.Add(multiTrigger);
        //RegisterButton.IsEnabled = false;
    }

    private void PhoneEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ValidateInputs();
    }

    private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ValidateInputs();
    }

    private void TermsAndConditionCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ValidateInputs();
    }

    private void ValidateInputs()
    {
        bool isPhoneNumberValid = IsPhoneNumberValid(PhoneEntry.Text);
        bool isPasswordValid = IsPasswordValid(PasswordEntry.Text);
        bool isCheckboxChecked = TermsAndConditionCheckbox.IsChecked;

        RegisterButton.IsEnabled = isPhoneNumberValid && isPasswordValid && isCheckboxChecked;
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            InvalidPhoneNumMsg.IsVisible = true;
            return false;
        }

        if (!phoneNumber.All(char.IsDigit))
        {
            InvalidPhoneNumMsg.IsVisible = true;
            return false;
        }

        InvalidPhoneNumMsg.IsVisible = false;
        return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
    }

    private bool IsPasswordValid(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            InvalidPasswordMsg.IsVisible = true;
            return false;
        }

        if (password.Length < 6)
        {
            InvalidPasswordMsg.IsVisible= true;
            return false;
        }

        InvalidPasswordMsg.IsVisible = false;
        return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
    }
}