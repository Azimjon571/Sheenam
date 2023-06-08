//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;
using Xeptions;

namespace Sheenam.Api.Services.Foundations.Hosts
{
    public partial class HostService
    {
        private delegate ValueTask<HoSt> ReturningFunction();

        private async ValueTask<HoSt> TryCatch(ReturningFunction returningFunction)
        {
            try
            {
                return await returningFunction();
            }
            catch (NullHostException nullHostException)
            {
                throw CreateAdnLogValidationException(nullHostException);
            }
            catch(InvalidHostException invalidHostException)
            {
                throw CreateAdnLogValidationException(invalidHostException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistHostException =
                    new AlreadyExistHostException(duplicateKeyException);

                throw CreateAdnLogDependencyValidationException(alreadyExistHostException);
            }
        }

        private HostValidationException CreateAdnLogValidationException(Xeption exception)
        {
            var hostValidationException =
                    new HostValidationException(exception);

            this.loggingBroker.LogError(hostValidationException);

            return hostValidationException;
        }

        private HostDependencyValidationException CreateAdnLogDependencyValidationException(Xeption exception)
        {
            var hostDependencyValidationException =
                new HostDependencyValidationException(exception);

            this.loggingBroker.LogError(hostDependencyValidationException);

            return hostDependencyValidationException;
        }
    }
}
