﻿// analyzer: D2L.CodeStyle.Analyzers.ServiceLocator.OldAndBrokenServiceLocatorAnalyzer

using System;
using D2L.LP.Extensibility.Activation.Domain;

namespace D2L.LP.Extensibility.Activation.Domain {
	public interface IServiceLocator { }

	public class OldAndBrokenServiceLocator {
		public static IServiceLocator Instance {
			get { return null; }
		}
	}

	public class OldAndBrokenServiceLocatorFactory {
		public IServiceLocator Create() { return null; }
	}
}

namespace D2L.CodeStyle.Analyzers.OldAndBrokenLocator.Examples {
	public sealed class FooDependency { }
	public sealed class BarDependency { }

	public sealed class BadClass {

		public BadClass() { }

		public void UsesBrokenLocator() {
			IServiceLocator locator = /* OldAndBrokenLocatorIsObsolete */ OldAndBrokenServiceLocator /**/.Instance;
		}

		public void UsesBrokenLocatorFactory() {
			IServiceLocator locator = new /* OldAndBrokenLocatorIsObsolete */ OldAndBrokenServiceLocatorFactory /**/().Create();
		}
	}

	public sealed class SketchyButNotYetOutlawedInjection {
		IServiceLocator m_locator;

		public SketchyButNotYetOutlawedInjection(
			IServiceLocator injectedLocator
		) {
			m_locator = injectedLocator;
		}
	}

	public sealed class GoodInjection {
		FooDependency m_foo;
		BarDependency m_bar;

		public GoodInjection(
			FooDependency injectedFoo,
			BarDependency injectedBar
		) {
			m_foo = injectedFoo;
			m_bar = injectedBar;
		}
	}
}
