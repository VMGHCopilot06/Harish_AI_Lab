try
{
    // Perform an operation
}
catch (Exception ex)
{
    if (ex is InvalidOperationException || ex is ArgumentNullException)
    {
        // Handle the specific exceptions
    }
    else
    {
        throw;
    }
}