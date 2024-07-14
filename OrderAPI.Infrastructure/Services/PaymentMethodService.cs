﻿using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Interfaces.Repositories;
using OrderAPI.ApplicationCore.Interfaces.Services;
using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
        public async Task<int> DeletePaymentMethod(int paymentMethodId)
        {
            var result = await _paymentMethodRepository.DeletePaymentMethod(paymentMethodId);
            return result;
        }

        public async Task<IEnumerable<PaymentMethodViewModel>> GetPaymentMethods(Guid customerId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            List<PaymentMethodViewModel> paymentMethodViewModels = new List<PaymentMethodViewModel>();
            var result = await _paymentMethodRepository.GetPaymentMethods(customerId);
            foreach (var model in result)
            {
                var paymentMethodViewModel = mapper.Map<PaymentMethodViewModel>(model);
                paymentMethodViewModel.PaymentTypeName = ((OrderAPI.ApplicationCore.Enum.PaymentType)paymentMethodViewModel.PaymentTypeId).ToString();
                paymentMethodViewModels.Add(paymentMethodViewModel);
            }

            return paymentMethodViewModels;
        }

        public async Task<int> SavePaymentMethod(PaymentMethodViewModel paymentMethods)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var model = mapper.Map<PaymentMethods>(paymentMethods);
            var result = await _paymentMethodRepository.SavePaymentMethod(model);
            return result;
        }

        public async Task<int> UpdatePaymentMethod(PaymentMethodViewModel paymentMethods)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var model = mapper.Map<PaymentMethods>(paymentMethods);
            var result = await _paymentMethodRepository.UpdatePaymentMethod(model);
            return result;
        }
    }
}
